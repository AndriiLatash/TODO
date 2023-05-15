using AutoMapper;
using TodoListWebApp.Models;
using TodoListWebApp.ViewModels;

namespace TodoListWebApp.Automapper
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Categories, TODOlist>()
				.ForMember(dst => dst.CategoryName,
				opt => opt.MapFrom(src => src.CategoryName))
				.ForMember(dst => dst.CategoryList,
				opt => opt.MapFrom(src => src.CategoryName));

			CreateMap<TODOlist, EditViewModel>()
		   .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.TaskId))
		   .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status));


		}
	}
}
