# AutoMapper

AutoMapper is a library that helps you map one object to another, typically used for mapping between data transfer objects (DTOs) and domain models. It can be particularly useful in scenarios where you have complex object graphs and want to avoid writing repetitive mapping code.
It uses conventions to automatically map properties with the same name and type, reducing the amount of boilerplate code you need to write.
It also supports custom mappings, flattening of complex objects, and collections.


## How to use AutoMapper

1. **Create Mapping Profiles**: Define your mapping configurations in a profile class that inherits from `Profile`.

   ```csharp
   using AutoMapper;
   using MyProject.Models;
   using MyProject.DTOs;
   using System;
   using System.Collections.Generic;
   using System.Linq;
   using System.Threading.Tasks;

   public class MappingProfile : Profile
   {
       public MappingProfile()
       {
           CreateMap<User, UserDto>();
           CreateMap<UserDto, User>();
           CreateMap<Order, OrderDto>();
           CreateMap<OrderDto, Order>();
       }
   }
   ```

2. **Initialize AutoMapper**: In your application startup, initialize AutoMapper with the profiles you created.

   ```csharp
   using AutoMapper;
   using Microsoft.Extensions.DependencyInjection;
   using MyProject.Mapping;
   using System;
   using System.Collections.Generic;
   using System.Linq;
   using System.Threading.Tasks;

   public class Startup
   {
       public void ConfigureServices(IServiceCollection services)
       {
           services.AddAutoMapper(typeof(MappingProfile));
           // Other service registrations...
       }
   }

   public class GetOrderQuery : IQuery<OrderDto>
   {
       public Guid OrderId { get; set; }
   }
   ```

3. **Use AutoMapper**: Inject `IMapper` into your classes and use it to map between objects.

   ```csharp
   using AutoMapper;
   using MyProject.DTOs;
   using MyProject.Models;
   using System;
   using System.Collections.Generic;
   using System.Linq;
   using System.Threading.Tasks;
   public class OrderService
   {
       private readonly IMapper _mapper;

       public OrderService(IMapper mapper)
       {
           _mapper = mapper;
       }

       public OrderDto GetOrderDto(Order order)
       {
           return _mapper.Map<OrderDto>(order);
       }

       public Order CreateOrder(OrderDto orderDto)
       {
           return _mapper.Map<Order>(orderDto);
       }
   }
   ```
4. **Custom Mappings**: If you need to customize the mapping, you can do so in the profile.

   ```csharp
   CreateMap<User, UserDto>()
       .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
   ```
5. **Flattening**: AutoMapper can flatten complex objects into a single object.

   ```csharp
   CreateMap<Order, OrderDto>()
       .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.Name))
       .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name));
   ```