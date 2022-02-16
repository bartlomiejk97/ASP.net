using AutoMapper;
using LibApp_Gr3.Models.DTO;

namespace LibApp_Gr3.Models
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            Books();
            Customer();
        }

        private void Books()
        {
            CreateMap<Book, BookDTO>()
                .ReverseMap();
        }

        private void Customer()
        {
            CreateMap<Customer, CustomerDTO>()
                .ReverseMap();
        }
    }
}
