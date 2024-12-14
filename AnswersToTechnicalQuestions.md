**1- تقریبا 7 ساعت روی این تسک وقت گذاشتم.اگر میخواستم وقت بیشتری بذارم احتمالا بهش Unit test  اظافه میکردم. و اکسپشن هنلندلینگ بهتری پیاده میکردم.**

**2- داخل ورژنهای آخر سیشارپ فیچر خیلی خارق العاده ای اظافه نشده. شاید بشه پرایمری کانستراکتور اشاره کرده**
‍‍‍‍‍‍
```csharp
public class Person(string name, int age)
{
    public string Name { get; } = name;
    public int Age { get; } = age;

    public override string ToString() => $"{Name}, {Age} years old";
}
```

**3- خب معمولا مانیتورینگ و لاگ هارو اول چک میکنم که مشخص بشه مشکل از منابعه یا چیز دیگری. با این بررسی ها معمولا محدوده ی جستجو برای پیدا کردن سرچ کوچکتر میشود بسته به نوع مشکل به دنبال راه حلش میگردیم.
 ممکنه با بهینه کردن کوئری های دیتابیسی حل بشه یا مموری لیک داشته باشیم. بله منم تجربه این مورد را داشتم.در شرکت فعلی که مشغول به کارم با بررسی لاگها و مشورت با بقیه اعظای تیم تصمیم گرفتیم معماری پروژه را از orchestration به choreography تغییر دهیم.**

**4- به صورت فصلی کتابهای C# in a nutshell و CLR via C# v را مطالعه کردم. نحوه ی عملکرد گاربیج کالکتور رو متوجه شدم**

**5-نظر خاصی  ندارم**
```json
{
  "name": "Mohammad Reza Alizadeh",
  "role": ".NET Developer",
  "contact": {
    "email": "mohammad.reza@gmail.com",
    "phone": "+98 9198500000",
    "linkedin": "linkedin.com/in/mohammad-reza-alizadeh",
    "location": "Tehran, Iran"
  },
  "summary": "Experienced .NET Developer with 6+ years of expertise in building and optimizing scalable systems for diverse industries, such as advertising platforms and fintech",
  "education": {
    "degree": "Bachelor's in Electrical Engineering",
    "institution": "Qom University",
    "dates": "Sep 2012 – Jul 2017",
    "thesis": "Face recognition using Deep Neural Network"
  },
  "languages": {
    "English": "Professional Working Proficiency"
  }
}
```

