using AutoMapper;
using JaygahYar.Application.DTOs;
using JaygahYar.Domain.Entities;

namespace JaygahYar.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Station, StationDto>();
        CreateMap<ServiceReportItem, ServiceReportItemDto>();
        CreateMap<OilToolInstallationForm, OilToolInstallationFormDto>();
        CreateMap<TankMonitoringInstallationForm, TankMonitoringInstallationFormDto>();
        CreateMap<AfterSalesServiceReport, AfterSalesServiceReportDto>();
        CreateMap<Stage2DeliveryForm, Stage2DeliveryFormDto>();
        CreateMap<Stage3DeliveryForm, Stage3DeliveryFormDto>();

        CreateMap<CreateStationRequest, Station>();
        CreateMap<CreateServiceReportItemRequest, ServiceReportItem>()
            .ForMember(d => d.TotalAmount, o => o.MapFrom(s => s.Quantity * s.Price));
    }
}