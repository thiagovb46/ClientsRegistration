using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientsRegistration.Application.Dto;
namespace ClientsRegistration.Application.ExternalServices.Interfaces
{
    public interface ICepService
    {
        Task<AddressDto> VerifyAddress(AddressDto dto);
    }
}
