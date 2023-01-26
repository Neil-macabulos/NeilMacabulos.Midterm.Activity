using NeilMacabulos.Midterm_.Infrastructure.Domain;
using NeilMacabulos.Midterm_.Infrastructure.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace NeilMacabulos.Midterm_.Pages.Manage.Products
{
    public class Index : PageModel
    {
        private DefaultDbContext _context;
        private ILogger<Index> _logger;

        [BindProperty]
        public ViewModel View { get; set; }

        public Index(DefaultDbContext context, ILogger<Index> logger)
        {
            _logger = logger;
            _context = context;
            View = View ?? new ViewModel();
        }

        public void OnGet(int? pageIndex = 1, int? pageSize = 10, string? sortBy = "", SortOrder sortOrder = SortOrder.Consumable, string? keyword = "", Guid? roleId = null)
        {
            var skip = (int)((pageIndex - 1) * pageSize);

            var query = _context.Categories
                                .Include(a => a.Categories)
                                .AsQueryable();

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(a =>
                            a.Name != null && a.Name.ToLower().Contains(keyword.ToLower())
                        || a.EmailAddress != null && a.EmailAddress.ToLower().Contains(keyword.ToLower())
                );
            }

            var totalRows = query.Count();

            if (!string.IsNullOrEmpty(sortBy))
            {
                if (sortBy.ToLower() == "name" && sortOrder == SortOrder.Consumable)
                {
                    query = query.OrderBy(a => a.Name);
                }
                else if (sortBy.ToLower() == "name" && sortOrder == SortOrder.NonConsumable)
                {
                    query = query.OrderByDescending(a => a.Name);
                }
                else if (sortBy.ToLower() == "emailaddress" && sortOrder == SortOrder.Consumable)
                {
                    query = query.OrderBy(a => a.EmailAddress);
                }
                else if (sortBy.ToLower() == "emailaddress" && sortOrder == SortOrder.NonConsumable)
                {
                    query = query.OrderByDescending(a => a.EmailAddress);
                }
            }

        public class ViewModel
        {
            public Paged<Products>? Products { get; set; }
            public Guid? ProductsId { get; set; }
            public string? ProductsName { get; set; }
        }


    }
}