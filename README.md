# PhoneBookApp

**Proje Açıklaması**

PhoneBook API, kişisel bilgileri (telefon numarası, adres, e-posta gibi) depolayan ve raporlama süreçlerini yöneten bir web API'sidir. API, PostgreSQL veritabanı ve Kafka kullanarak veri akışını yönetir.

Gereksinimler

- PostgreSQL: Veritabanı olarak PostgreSQL kullanılmaktadır. PostgreSQL'in bilgisayarınızda kurulu olması gerekmektedir.
- Kafka: Kafka verilerin kuyruklanmasını sağlamak için kullanılmaktadır. Kafka'nın bilgisayarınızda kurulu olması ve localhost:9092 üzerinden erişilebilir olması gerekmektedir.
- Proje .NET 8.0 ile geliştirilmiştir.
- Visual Studio veya benzeri bir IDE: Projeyi geliştirmek ve çalıştırmak için kullanılabilir.

Kurulum Adımları

1. PostgreSQL ve Kafka'nın Kurulması

Projenin düzgün çalışabilmesi için PostgreSQL ve Kafka'nın bilgisayarınızda kurulu olması gerekmektedir. 

2. Veritabanı Ayarları

Veritabanı bağlantı ayarları appsettings.json dosyasında yer almaktadır. Veritabanı bağlantı dizesini kendi bilgisayarınıza uygun şekilde güncelleyin:

    json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Host=localhost;Port=5432;Username=userName;Password=password;Database=PhoneBook;"
      }
    }

3. Migration ve Veritabanı Güncellemesi

Projenin veritabanı şeması ve başlangıç verileri için migration işlemi yapılmalıdır. Bunun için terminal veya komut satırından aşağıdaki adımları takip edin:

  3.1. Migration'ı Uygulama:
   
     dotnet ef database update
   
  Bu komut veritabanını güncelleyecek ve gerekli tabloları oluşturacaktır.

  3.2. Enum Değerlerinin Veritabanına Eklenmesi:

  ContactInfoTypeEnum ve ReportStatusEnum enum değerleri veritabanına eklenmelidir. PostgreSQL'e aşağıdaki SQL komutlarını çalıştırarak bu verileri ekleyebilirsiniz:

     insert into public."ReportStatus" values (1, 'Pending');
     insert into public."ReportStatus" values (2, 'Completed');
     insert into public."ReportStatus" values (3, 'Failed');
  
     insert into public."ContactInfoType" values (1, 'Location');
     insert into public."ContactInfoType" values (2, 'PhoneNumber');
     insert into public."ContactInfoType" values (3, 'MailAddress');
   
  Bu sorgular, veritabanına enum değerlerini ekleyecek ve sistemin doğru çalışabilmesini sağlayacaktır.

4. Kafka Ayarları

Proje Kafka kullanmaktadır ve aşağıdaki ayarları doğru bir şekilde yapılandırmalısınız:

1. Kafka'nın doğru şekilde çalıştığından emin olun. Kafka'yı *localhost:9092* üzerinden dinleyecek şekilde kurmanız gerekmektedir.
2. Kafka'nın doğru şekilde başlatıldığından emin olmak için aşağıdaki komutu kullanabilirsiniz:

       kafka-server-start.bat config/server.properties

5. API'yi Kullanma

API'ye yapılacak istekler için swaggerda mevcut olan uç noktaları kullanabilirsiniz.

Proje Yapısı

- PhoneBook.Api: API kontrolcülerinin bulunduğu katman.
- PhoneBook.Services: İş mantığının yer aldığı servisler.
- PhoneBook.Data: Veritabanı erişim katmanı ve model sınıfları.
- PhoneBook.Shared: Paylaşılan modeller ve yardımcı sınıflar.
