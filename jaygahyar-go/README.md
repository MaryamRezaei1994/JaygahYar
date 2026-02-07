# JaygahYar (Go)

نسخه‌ی Go از پروژه‌ی JaygahYar با معماری Clean Architecture و API مشابه نسخه‌ی `.NET`.

## تکنولوژی‌ها

- Go + Gin
- PostgreSQL
- GORM

## ساختار

```
jaygahyar-go/
  cmd/api/                 # entrypoint
  internal/domain/         # entities + repository interfaces
  internal/app/            # services (use-cases)
  internal/infra/          # db + repository implementations
  internal/transport/http/ # http handlers (gin)
```

## اجرا

1) تنظیم متغیرها

فایل `.env.example` را کپی کنید به `.env` و مقدار `DATABASE_URL` را ست کنید.

2) اجرا

```bash
cd jaygahyar-go
go run ./cmd/api
```

Healthcheck:

- `GET /healthz`

API base:

- `/api/Stations`
- `/api/OilToolInstallationForms`
- `/api/TankMonitoringInstallationForms`
- `/api/AfterSalesServiceReports`
- `/api/Stage2DeliveryForms`
- `/api/Stage3DeliveryForms`

## نکته

فعلاً برای سادگی، در زمان اجرا از `AutoMigrate` استفاده شده است.

