using AutoMapper;
using Store.Model;
using Store.Services;
using Store.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Store.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IGadgetService _gadgetService;
        private readonly IMapper _mapper;

        public HomeController(ICategoryService categoryService, IGadgetService gadgetService, IMapper mapper)
        {
            _categoryService = categoryService;
            _gadgetService = gadgetService;
            _mapper = mapper;
        }

        public ActionResult Index(String category = null)
        {
            IEnumerable<Category> categories = _categoryService.GetCategories(category).ToList();
            
            IEnumerable<CategoryViewModel> viewModelGadgets = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(categories);

            return View(viewModelGadgets);
        }

        public ActionResult Filter(String category, String gadgetName)
        {
            var gadgets = _gadgetService.GetCategoryGadgets(category, gadgetName);

            IMapper mapper = new MapperConfiguration(x => x.CreateMap<Gadget, GadgetViewModel>()).CreateMapper();

            var viewModelGadgets = mapper.Map<IEnumerable<Gadget>, IEnumerable<GadgetViewModel>>(gadgets);

            return View(viewModelGadgets);
        }

        [HttpPost]
        public ActionResult Create(GadgetFormViewModel newGadget)
        {
            if (newGadget?.File != null)
            {
                IMapper mapper = new MapperConfiguration(x => x.CreateMap<GadgetFormViewModel, Gadget>()).CreateMapper();

                var gadget = mapper.Map<GadgetFormViewModel, Gadget>(newGadget);
                _gadgetService.CreateGadget(gadget);

                String gadgetPicture = System.IO.Path.GetFileName(newGadget.File.FileName);
                String path = System.IO.Path.Combine(Server.MapPath("~/images/"), gadgetPicture);
                newGadget.File.SaveAs(path);

                _gadgetService.SaveGadget();
            }

            var category = _categoryService.GetCategory(newGadget.GadgetCategory);
            return RedirectToAction("Index", new {category = category.Name});
        }
    }
}