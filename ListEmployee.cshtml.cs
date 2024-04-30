using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using SimpleRazorApp.Services;
using SimpleRazorApp.Pages;
using Microsoft.AspNetCore.Mvc;

public class ListEmployeeModel : PageModel
{
    private readonly EmployeeManager _employeeManager;
    [BindProperty]
    public Employees Employee { get; set; }

    public ListEmployeeModel(EmployeeManager employeeManager)
    {
        _employeeManager = employeeManager; // Fix: Assign the value passed in the constructor parameter to the _employeeManager variable.
    }

    public IEnumerable<Employees>? employee { get; private set; }

    public async Task OnGetAsync()
    {
        employee = await _employeeManager.GetEmployeeList();
    }
}