# JaygahYar

سیستم مدیریت جایگاه‌های سوخت و خدمات پس از فروش نفت‌ابزار — پیاده‌سازی با **.NET 8** و **معماری Clean Architecture**.

---

## معرفی

JaygahYar یک API برای مدیریت اطلاعات جایگاه‌های سوخت (جایگاه)، فرم‌های نصب تجهیزات، گزارش‌های خدمات پس از فروش و فرم‌های تحویل/راه‌اندازی استیج ۲ و ۳ (تجهیزات جمع‌آوری و بازیافت بخار بنزین) است.

---

## قابلیت‌ها

| ماژول | توضیح |
|--------|--------|
| **جایگاه (Station)** | مدیریت جایگاه‌های سوخت (نام، آدرس، تلفن، تعداد مخازن بنزین/نفت‌گاز) |
| **فرم نصب نفت‌ابزار** | ثبت نصب دیسپنسرها و چک‌لیست نصب (شات‌آف والو، چک والو، گلند و ...) |
| **فرم مانیتورینگ مخازن** | نصب سیستم مانیتورینگ مخازن با پراب‌ها و چک‌لیست راه‌اندازی |
| **گزارش خدمات پس از فروش** | ثبت سرویس، قطعات، اقدامات ایمنی و هزینه‌ها |
| **فرم تحویل استیج ۲** | تحویل/راه‌اندازی تجهیزات جمع‌آوری بخار (STAGE II) |
| **فرم تحویل استیج ۳** | تحویل/راه‌اندازی دستگاه بازیافت بخار VRU (STAGE III) |

---

## فناوری‌ها

- **.NET 8**
- **ASP.NET Core Web API**
- **Entity Framework Core 8** + **Npgsql (PostgreSQL)**
- **Clean Architecture** (Domain, Application, Infrastructure, WebAPI)
- **AutoMapper** — نگاشت Entity ↔ DTO
- **FluentValidation** — اعتبارسنجی ورودی
- **Redis (StackExchange.Redis)** — کش نتایج GET (مشابه پروژه Survey)
- **Swagger / OpenAPI** — مستندات و تست API

---

## معماری

پروژه بر اساس **Clean Architecture** در چهار لایه سازماندهی شده است:

```
┌─────────────────────────────────────────────────────────┐
│                    JaygahYar.WebAPI                      │  ← Controllers, ورودی HTTP
├─────────────────────────────────────────────────────────┤
│                 JaygahYar.Infrastructure                 │  ← EF Core, Repositoryها, UnitOfWork
├─────────────────────────────────────────────────────────┤
│                 JaygahYar.Application                    │  ← سرویس‌ها، DTOها، Validatorها، Mapping
├─────────────────────────────────────────────────────────┤
│                  JaygahYar.Domain                       │  ← Entityها، Enumها، Interfaceهای Repository
└─────────────────────────────────────────────────────────┘
```

- **Domain:** موجودیت‌ها، Enumها و قراردادهای Repository — بدون وابستگی به فریم‌ورک.
- **Application:** منطق کسب‌وکار، DTOها، سرویس‌ها و اعتبارسنجی — وابسته فقط به Domain.
- **Infrastructure:** پیاده‌سازی دسترسی به داده (EF Core، Repositoryها، UnitOfWork) — وابسته به Application و Domain.
- **WebAPI:** کنترلرها و پیکربندی برنامه — وابسته به Infrastructure و Application.

---

## ساختار پروژه

```
JaygahYar/
├── JaygahYar.sln
├── README.md
└── src/
    ├── JaygahYar.Domain/           # لایه دامنه
    │   ├── Common/                 # BaseEntity، Enums
    │   ├── Configuration/          # ConfigurationData (الگوی Survey)
    │   ├── Entities/               # Station، فرم‌های نصب، گزارش پس از فروش، ...
    │   └── Interfaces/             # IRepository، IUnitOfWork، Repositoryهای اختصاصی
    │
    ├── JaygahYar.Application/      # لایه کاربرد
    │   ├── Constants/              # CacheExtensions (Redis JSON)
    │   ├── DTOs/                   # مدل‌های ورودی/خروجی API
    │   ├── Interfaces/              # قرارداد سرویس‌ها
    │   ├── Mapping/                 # پروفایل AutoMapper
    │   ├── Services/                # پیاده‌سازی سرویس‌ها
    │   └── Validators/              # FluentValidation
    │
    ├── JaygahYar.Infrastructure/   # لایه زیرساخت
    │   ├── Persistence/             # ApplicationDbContext
    │   └── Repositories/            # Repositoryها و UnitOfWork
    │
    └── JaygahYar.WebAPI/            # لایه ارائه
        ├── Controllers/             # Stations، OilToolInstallationForms، ...
        ├── Program.cs
        └── appsettings.json
```

> نسخه Go هم در فولدر `jaygahyar-go/` موجود است.

---

## پیش‌نیازها

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- PostgreSQL
- (اختیاری) Redis (برای فعال بودن کش)

---

## راه‌اندازی

### ۱. کلون کردن مخزن

```bash
git clone https://github.com/MaryamRezaei1994/JaygahYar.git
cd JaygahYar
```

### ۲. بازسازی و اجرا

```bash
dotnet restore
dotnet build
cd src/JaygahYar.WebAPI
dotnet run
```

یا از ریشهٔ solution:

```bash
dotnet run --project src/JaygahYar.WebAPI/JaygahYar.WebAPI.csproj
```

پس از اجرا، Swagger از آدرسی مشابه زیر در دسترس است:

- **Swagger UI:** `https://localhost:7xxx/swagger` (پورت در خروجی ترمینال نمایش داده می‌شود)

---

## پیکربندی

### تنظیم Environment (الگوی Survey)

در **`src/JaygahYar.WebAPI/appsettings.json`**:

- **Environment**: تعیین پروفایل کانفیگ (مثلاً `DEVELOPMENT`, `TEST`, `SQA`)
- **Version**: نسخه سرویس

### تنظیم Connection String دیتابیس

الگوی پروژه مثل `Survey` است و connection string از داخل `ConfigurationData` تامین می‌شود:

- **DEBUG**: بر اساس مقدار `Environment` در `appsettings.json` انتخاب می‌شود.
- **RELEASE**: از متغیر محیطی خوانده می‌شود:
  - `DB_PG_CONNECTION`

> اجرای Migration در استارتاپ انجام می‌شود (`db.Database.MigrateAsync()` در `Program.cs`).

### تنظیم Redis برای کش

کش (مانند پروژه Survey) با Redis پیاده شده است. مقادیر Redis نیز در `ConfigurationData` نگهداری می‌شوند:

- **DEBUG**: بر اساس `Environment` مقداردهی می‌شود.
- **RELEASE**: از متغیرهای محیطی خوانده می‌شود:
  - `DB_REDIS_CONNECTION`
  - `DB_REDIS_USERNAME`
  - `DB_REDIS_PASSWORD`

> TTL کش پیش‌فرض ۵ دقیقه است و در عملیات Create/Update/Delete کلیدهای مرتبط invalidate می‌شوند.

### نکته امنیتی

بهتر است اطلاعات حساس (پسورد DB/Redis) در ریپو commit نشوند و فقط از **متغیر محیطی** یا **User Secrets** استفاده شود.

---

## APIها (خلاصه)

| پایه | توضیح |
|------|--------|
| `GET/POST/PUT/DELETE /api/Stations` | CRUD جایگاه |
| `GET/POST /api/Stations/{id}` | جزئیات و ایجاد جایگاه |
| `GET /api/OilToolInstallationForms/station/{stationId}` | فرم‌های نصب نفت‌ابزار یک جایگاه |
| `GET /api/TankMonitoringInstallationForms/station/{stationId}` | فرم‌های مانیتورینگ مخازن یک جایگاه |
| `GET /api/AfterSalesServiceReports/station/{stationId}` | گزارش‌های پس از فروش یک جایگاه |
| `GET /api/Stage2DeliveryForms/station/{stationId}` | فرم‌های تحویل استیج ۲ یک جایگاه |
| `GET /api/Stage3DeliveryForms/station/{stationId}` | فرم‌های تحویل استیج ۳ یک جایگاه |

مستندات کامل و امتحان درخواست‌ها در **Swagger** موجود است.

---

## مشارکت و گزارش باگ

برای مشارکت یا گزارش مشکل می‌توانید از **Issues** و **Pull Request**های همین مخزن در GitHub استفاده کنید.

---

## لایسنس

این پروژه تحت لایسنس MIT منتشر شده است.
