using AutoMapper;
using JaygahYar.Application.DTOs;
using JaygahYar.Domain.Common.Enums;
using JaygahYar.Domain.Entities;

namespace JaygahYar.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Station, StationDto>();
        CreateMap<DispenserInstallationItem, DispenserInstallationItemDto>();
        CreateMap<ProbeItem, ProbeItemDto>();
        CreateMap<ServiceReportItem, ServiceReportItemDto>();

        CreateMap<OilToolInstallationForm, OilToolInstallationFormDto>()
            .ForMember(d => d.StationType, o => o.MapFrom(s => s.StationType.HasValue ? s.StationType.Value.ToString() : null));

        CreateMap<TankMonitoringInstallationForm, TankMonitoringInstallationFormDto>();
        CreateMap<AfterSalesServiceReport, AfterSalesServiceReportDto>();
        CreateMap<Stage2DeliveryForm, Stage2DeliveryFormDto>();
        CreateMap<Stage3DeliveryForm, Stage3DeliveryFormDto>();

        CreateMap<CreateStationRequest, Station>();
        CreateMap<CreateDispenserItemRequest, DispenserInstallationItem>();
        CreateMap<CreateProbeItemRequest, ProbeItem>();
        CreateMap<CreateServiceReportItemRequest, ServiceReportItem>()
            .ForMember(d => d.TotalAmount, o => o.MapFrom(s => s.Quantity * s.Price));
    }
}
