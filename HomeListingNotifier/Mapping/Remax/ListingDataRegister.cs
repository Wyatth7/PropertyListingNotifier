using HomeListingNotifier.Extensions;
using HomeListingNotifier.Model.Remax;
using Mapster;
using Persistence.Entities;
using Persistence.Entities.Types;
using Address = Persistence.Entities.Address;

namespace HomeListingNotifier.Mapping.Remax;

public class ListingDataRegister : IGlobalRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<ListingData, Listing>()
            .Ignore(d => d.ListingId)
            .Map(d => d.RealEstateListingSiteId, s => (int)RealEstateSite.Remax)
            .Map(d => d.ListingProviderId, s => s.UniqueListingId ?? string.Empty)
            .Map(d => d.Resource, s => new Resource
            {
                Data = new
                {
                    s.UniqueListingId,
                    s.Upi,
                }.ToJson()
            })
            .Map(d => d.Properties, s => new List<Property>
            {
                new()
                {
                    PropertyTypeId = s.RawPropertyType != null ? (int)s.RawPropertyType.TryGetPropertyType() : 0,
                    Address = s.Location == null
                        ? null
                        : new Address
                        {
                            ListingAddressFull = s.Location.ListingAddressFull,
                            ListingAddress1 = s.Location.ListingAddress1,
                            ListingAddress2 = s.Location.ListingAddress2,
                            City = s.Location.City,
                            State = s.Location.State,
                            Country = s.Location.Country,
                            PostalCode = s.Location.PostalCode,
                            Timezone = s.Location.Timezone
                        },
                    ListingAgent = new ListingEntity
                    {
                        Name = s.ListingAgentFullName ?? string.Empty,
                        Email = string.Empty,
                        Phone = s.ListAgentPhone ?? string.Empty
                    },
                    ListingOffice = new ListingEntity
                    {
                        Name = s.ListOfficeName ?? string.Empty,
                        Email = s.ListOfficeEmail ?? string.Empty,
                        Phone = s.ListOfficePhone ?? string.Empty
                    },
                    PropertyDetails = new PropertyDetails
                    {
                        Bedrooms = s.BedroomsTotal.AsFloat(),
                        Bathrooms = s.BathroomsFull.AsFloat(),
                        LotSizeAcres = s.LotSizeAcres.AsFloat(),
                        LivingArea = s.LivingArea.AsFloat(),
                        LotSizeSqFeet = s.LotSizeSqFeet.AsFloat(),
                        Price = s.ListPrice.AsCurrency(),
                        PriceChange = s.PriceChangeAmount.AsCurrency(),
                        YearBuilt = s.YearBuilt.AsInt32(),
                        BaseImageUrl = s.ListingImages.GetBaseImageUrl()
                    },
                    Resource = new Resource
                    {
                        Data = s.Images.ToJson()
                    }
                }
            });
    }
}