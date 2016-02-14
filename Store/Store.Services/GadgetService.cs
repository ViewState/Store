using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Store.Data.Infrastructure;
using Store.Data.Repositories;
using Store.Model;

namespace Store.Services
{
    public interface IGadgetService
    {
        IEnumerable<Gadget> GetGadgets();
        IEnumerable<Gadget> GetCategoryGadgets(String categoryName, String gadgetName = null);
        Gadget GetGadget(int id);
        void CreateGadget(Gadget gadget);
        void SaveGadget();
    }

    public class GadgetService : IGadgetService
    {
        private readonly IGadgetRepository _gadgetsRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GadgetService(IGadgetRepository gadgetsRepository, ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _gadgetsRepository = gadgetsRepository;
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }
        
        public IEnumerable<Gadget> GetGadgets() => _gadgetsRepository.GetAll();

        public IEnumerable<Gadget> GetCategoryGadgets(String categoryName, String gadgetName = null)
        {
            var category = _categoryRepository.GetCategoryByName(categoryName);
            return category.Gadgets.Where(g => gadgetName != null && g.Name.ToLower().Contains(gadgetName));
        }

        public Gadget GetGadget(Int32 id) => _gadgetsRepository.GetById(id);

        public void CreateGadget(Gadget gadget) => _gadgetsRepository.Add(gadget);

        public void SaveGadget() => _unitOfWork.Commit();
    }
}
