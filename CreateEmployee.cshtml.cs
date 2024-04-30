using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SimpleRazorApp.Services;
// Add missing using directive
using SimpleRazorApp.Pages;
public class CreateEmployeeModel : PageModel
{
    private readonly EmployeeManager _employeeManager;
    
    [BindProperty]
    public Employees Employee { get; set; }
    public CreateEmployeeModel(EmployeeManager employeeManager)
    {
        _employeeManager = employeeManager;
    }
    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        await _employeeManager.SaveEmployeeInfo(Employee);
        return RedirectToPage("./ListEmployee");
    }
}
