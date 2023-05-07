1. Asp.Net Core Web App (Model-View-Controller) projesi açılır.
2. "Models > Entities" klasörü açılır.
	2.1 "Models > Entities > Abstract" klasörü açılır.
		2.1.1 "Models > Entities > Abstract" klasöründe BaseEntity.cs dosyası oluşturulur.
	2.2 "Models > Entities > Concrete" klasörü açılır.
		2.2.1 "Models > Entities > Concrete" klasöründe Page.cs dosyası oluşturulur.
		2.2.2 "Models > Entities > Concrete" klasöründe Category.cs dosyası oluşturulur.
		2.2.3 "Models > Entities > Concrete" klasöründe Product.cs dosyası oluşturulur.
3. "Infrastructure" klasörü açılır.
	3.1 "Infrastructure > Context" klasörü açılır.
		3.1.1 "Infrastructure > Context" klasöründe ApplicationDbContext.cs dosyası oluşturulur.
	3.2 "Infrastructure > Repositories" klasörü açılır.
		3.2.1 "Infrastructure > Repositories > Interfaces" klasörü açılır.
			3.2.1.1 "Infrastructure > Repositories > Interfaces" klasöründe IBaseRepository.cs interface dosyası oluşturuşur.
			3.2.1.2 "Infrastructure > Repositories > Interfaces" klasöründe IPageRepository.cs interface dosyası oluşturulup IBaseRepository.cs classı miras alınır.
			3.2.1.3 "Infrastructure > Repositories > Interfaces" klasöründe ICategoryRepository.cs interface dosyası oluşturulup IBaseRepository.cs classı miras alınır.
			3.2.1.4 "Infrastructure > Repositories > Interfaces" klasöründe IProductRepository.cs interface dosyası oluşturulup IBaseRepository.cs classı miras alınır.
		3.2.2 "Infrastructure > Repositories > Concrete" klasörü açılır.
			3.2.2.1 "Infrastructure > Repositories > Concrete > BaseRepository.cs" dosyası oluşturulur.
			3.2.2.2 "Infrastructure > Repositories > Concrete > PageRepository.cs" dosyası oluşturulur.
			3.2.2.3 "Infrastructure > Repositories > Concrete > CategoryRepository.cs" dosyası oluşturulur.
			3.2.2.4 "Infrastructure > Repositories > Concrete > ProductRepository.cs" dosyası oluşturulur.
4. "Models" klasörü içerisinde Projemizin işleyiş mantığına göre data transfer objelerimizin DTOs ve VM'lerini oluşturalım.
5. "Models" klasörü içerisinde "AutoMapper" klasörü oluşturalım.
	5.1. Nuget içerisinden "AutoMapper.Extensions.Microsoft.DependencyInjection" paketini yükleyelim.
	5.2. "Models > AutoMapper" klasörü içerisinde Mapping.cs sınıfı oluşturulur.
	5.3. Startup.cs sınıfı içerisinde ConfigureService metodu içerisinde AddAutoMapper() metodu ile oluşturulan Mapping tanımlanır.
	5.4. Startup.cs sınıfı içerisinde ConfigureService metodu içerisinde ApplicationDbContext tanımlaması yapılır.
	5.5. Startup.cs sınıfı içerisinde ConfigureService metodu içerisinde Repositoryler AddScoped metodu ile tanımlanarak bağımlılıklar oluşturulur.
6. "appsettings.json" dosyasında ConnectionString tanımlaması yapılır.
7. Migration yapılır.
8. PageController.cs oluşturulur.