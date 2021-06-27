using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.dbo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;

namespace WebApplication2.Pages.Departamentos
{
    public class EditModel : PageModel
    {
        private readonly IDepartamentosService departamentosService;

        public EditModel(IDepartamentosService departamentosService)
        {
            this.departamentosService = departamentosService;
        }

        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }

        [BindProperty]
        public DepartamentosEntity Entity { get; set; } = new DepartamentosEntity();

        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await departamentosService.GetById(entity: new() { Id_Departamento = id });
                }

                return Page();
            }

            catch (Exception ex)
            {

                return Content(ex.Message);
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (Entity.Id_Departamento.HasValue)
                {
                    //Para actualizar
                    var result = await departamentosService.Update(entity: Entity);

                    if (result.CodeError != 0)
                    {
                        throw new Exception(result.MsgError);
                    }

                    TempData[key: "Msg"] = "El registro ha sido actualizado";
                }
                else
                {
                    //Para nuevo registro
                    var result = await departamentosService.Create(entity: Entity);

                    if (result.CodeError != 0)
                    {
                        throw new Exception(result.MsgError);
                    }

                    TempData[key: "Msg"] = "El registro ha sido ingresado";

                }

                return RedirectToPage("Grid");
            }

            catch (Exception ex)
            {

                return Content(ex.Message);
            }
        }
    }
}
