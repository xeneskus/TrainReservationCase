<h1>Tren Rezervasyon Sistemi API</h1>

<p>Bu proje, bir tren rezervasyon sistemi geliştirme senaryosu için tasarlanmış bir HTTP API'dir. Bu API, belirli bir tren için rezervasyon taleplerini değerlendirir ve mümkünse hangi vagonda rezervasyon yapılabileceğini belirler.</p>

<h2>Proje Özeti</h2>
<p>Geliştirilen API, kullanıcıdan tren bilgileri ve kaç kişilik rezervasyon istenildiğine dair bir istek alır. API, her bir vagonun doluluk durumuna ve kurallara göre rezervasyon yapılıp yapılamayacağını hesaplar. Rezervasyon yapılabiliyorsa hangi vagonlarda kaç kişinin yerleştirileceğini belirler.</p>

<h2>Çözümün Temel Mantığı</h2>
<ul>
    <li>Bir trenin birden fazla vagonu olabilir, her vagonun belirli bir kapasitesi ve doluluk oranı vardır.</li>
    <li>Bir vagonun doluluk oranı %70'i aştığında o vagona daha fazla rezervasyon yapılamaz.</li>
    <li>Bir rezervasyon talebi birden fazla kişi için olabilir.</li>
    <li>Kullanıcılar tüm yolcuların aynı vagonda bulunmasını isteyebilir veya yolcuların farklı vagonlara yerleştirilmesine de izin verebilir.</li>
</ul>

<h2>API Gereksinimleri</h2>
<ul>
    <li><b>Birden fazla vagon:</b> Her trenin farklı kapasitelerde vagonları olabilir.</li>
    <li><b>Doluluk oranı kısıtlaması:</b> Her vagon, maksimum %70 doluluk oranına ulaşana kadar rezervasyon kabul eder.</li>
    <li><b>Toplu rezervasyonlar:</b> Bir rezervasyon talebi birden fazla kişi için olabilir ve bu kişilerin hangi vagona yerleştirileceği algoritma ile belirlenir.</li>
    <li><b>Aynı veya farklı vagonlar:</b> Rezervasyon isteği, kişilerin aynı vagonda ya da farklı vagonlara yerleştirilip yerleştirilemeyeceğini belirleyebilir.</li>
</ul>

<h2>API Kullanımı</h2>

<h3>1. İstek Formatı</h3>
<p>Kullanıcı, rezervasyon talebinde bulunduğunda API'ye aşağıdaki JSON formatında bir istek gönderir:</p>

<pre>
{
    "Tren":
    {
        "Ad":"Başkent Ekspres",
        "Vagonlar":
        [
            {"Ad":"Vagon 1", "Kapasite":100, "DoluKoltukAdet":68},
            {"Ad":"Vagon 2", "Kapasite":90, "DoluKoltukAdet":50},
            {"Ad":"Vagon 3", "Kapasite":80, "DoluKoltukAdet":80}
        ]
    },
    "RezervasyonYapilacakKisiSayisi":3,
    "KisilerFarkliVagonlaraYerlestirilebilir":true
}
</pre>

<h3>2. Yanıt Formatı</h3>
<p>API, istek doğrultusunda rezervasyonun yapılıp yapılamayacağını ve yerleşim detaylarını aşağıdaki gibi JSON formatında döner:</p>

<h4>Başarılı Rezervasyon:</h4>
<pre>
{
    "RezervasyonYapilabilir":true,
    "YerlesimAyrinti":[
        {"VagonAdi":"Vagon 1","KisiSayisi":2},
        {"VagonAdi":"Vagon 2","KisiSayisi":1}
    ]
}

</pre>

<h4>Başarısız Rezervasyon (Yer yoksa):</h4>
<pre>
{
    "RezervasyonYapilabilir": false,
    "YerlesimAyrinti": []
}
</pre>

<h2>Rezervasyon Kuralları</h2>
<ul>
    <li><b>Doluluk Oranı Kuralı:</b> Vagonlardaki doluluk oranı %70'i geçerse, o vagona yeni rezervasyon yapılamaz. Örneğin, kapasitesi 100 olan bir vagonda en fazla 70 koltuk dolu olabilir.</li>
    <li><b>Kişilerin Aynı Vagon ya da Farklı Vagonlarda Yerleşimi:</b> Eğer tüm yolcuların aynı vagonda yerleşmesi isteniyorsa ve yer yoksa rezervasyon reddedilir. Ancak farklı vagonlarda yerleşime izin veriliyorsa, yolcular uygun vagonlara dağıtılır.</li>
</ul>
