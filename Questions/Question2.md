Soru-2: Aşağıdaki C# koduyla ilgili gözüne takılan sorunları iletebilir misin?

public static User GetUserByName(string name) {
var connection = new MySqlConnection("Server=127.0.0.1;Database=test");
connection.Open();
return connection.Query<User>($“select * from users where name = {name}”).ToList().First();
}

-----------------------------------------------------------------------------------------------------
1- Connection açık kalmamalı. Her kullanımdan sonra bağlantı nesnemizi Close() ile kapatmalıyız. Dispose() methodunu kullanarak connection nesnemizin kullandığı kaynakları, ram,ağ bağlantısı gibi, serbest bırakılmasını, daha fazla kullanılmamasını sağlayabiliriz.
Database bağlantısı method içerisinde MySqlConnection sınıfından bir instance oluşturularak sağlanmış. Eğer GetUserByName(string name) methodunun içerisinde bulunduğu sınıftaki bütün methodlar bir MySqlConnection nesnesi kullanıyorsa, MySqlConnection nesnemizi sınıf için global bir nesne olarak tanımlamamız ve methodlarda o nesne üzerinden işlem yapmamız daha doğru olacaktır.
Ayrıca MySqlConnection sınıfı özelleştirilip, WepApplicationBuilder nesnesinin ServiceCollection'ına eklenerek kullanılmak istenen sınıfta Dependency Injection ile çağırılarak kullanılabilir.

-----------------------------------------------------------------------------------------------------
2- MySqlConnection nesnesine connection string doğrudan verilmiş. Connection string bir nesne içerisinde constant olarak veya uygulama konfigurasyon dosyalarında tutulabilir ve gerektiğinde oradan çağrılabilir.
Ayrıca MySql için connection string tanımının bu şekilde olup olmadığı hakkında bir bilgim yok ancak sadece server ve database bilgileri ile bağlantı sağlanmayabilir. User ID ve password istiyor olmalı diye düşünüyorum.

public static class ConnectionStrings
{
   public const string InfosetDbConnectionString = "Server=127.0.0.1;Database=test";
}
appSettings.json {
    "ConnectionStrings" : {
        InfosetDbConnectionString = "Server=127.0.0.1;Database=test"
    }
}

-----------------------------------------------------------------------------------------------------
3- name parametresi doğrudan sorgunun içerisinde string interpolation uygulanarak eklenmiş. Bu, veritabanına istenmeyen sorgular gitmesine (SQL Injection) sebep olabilir. Parametre, istenmeyen ifadelerden (select, delete, drop, alter, exec vs.) oluşuyor olabilir. Sorguyu çalıştırmadan önce bu gibi ifadeler kontrol edilerek önlem alınabilir. 
Sorguya eklenmek istenen parametre, Dapper'ın Query() methodunun 2. overloadına parametre olarak gönderilebilir. 

User user = connection.Query<User>("SELECT * FROM users WHERE name = @Name", new { Name = name }).ToList().First();

Bir diğer alternatif ise MySqlCommand nesnesini ve Parameters.AddWithValue methodunu kullanmak :

MySqlCommand command = new("SELECT * FROM users WHERE name = @Name",connection);
command.Parameters.AddWithValue("@Name",name); 
MySqlDataReader reader = command.ExecuteReader();
...

-----------------------------------------------------------------------------------------------------
4- connection.Query<User>().ToList().First(); methodunda ToList() kullanarak, gelen User nesnesi önce bir listeye atanıp sonrasında .First() methodu ile elde edilmiş. Query() methodu zaten IEnumerable dönüş tipine sahip olduğu için ToList() methodu kaldırılarak sadece First() methodu ile de elde edilebilir.

User user = connection.Query<User>("SELECT * FROM users WHERE name = @Name", new { Name = name }).First();

First() methodunu kullanırken öncesindeki ifadedeki koleksiyonda bir veri yoksa, yani veritabanına gönderdiğimiz sorgu sonucunda bir veri geri dönmediyse "System.InvalidOperationException: Sequence contains no elements..." hatasını fırlatacaktır.
Bu hatayı önlemek için First() methodunu kullanmadan önce koleksiyonda herhangi bir veri olup olmadığını kontrol eden bir koşul ifadesi yazılabilir. Veya First() yerine FirstOrDefault() methodunu kullanarak, koleksiyonda veri yoksa default değer (null?) döndürülebilir. 

-----------------------------------------------------------------------------------------------------
5- var connection = new MySqlConnection("Server=127.0.0.1;Database=test") satırında connection nesnesi, tipi MySqlConnection olmasına rağmen "var" keywordü ile işaretlenmiş. Türünü bildiğimiz değişkenleri türüyle işaretlemek, az da olsa compilerın yükünü hafifletir, bellek optimizasyonu sağlar.

var --> compile , derleme aşamasında
dynamic --> runtime , uygulama çalıştığında