using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.dbo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;

namespace WebApplication2.Pages.Puestos
{
    public class EditModel : PageModel
    {
        private readonly IPuestosService puestosService;

        public EditModel(IPuestosService puestosService)
        {
            this.puestosService = puestosService;
        }

        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }

        [BindProperty]
        public PuestosEntity Entity { get; set; } = new PuestosEntity();

        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await puestosService.GetById(entity: new() { Id_Puesto = id });
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
                if (Entity.Id_Puesto.HasValue)
                {
                    //Para actualizar
                    var result = await puestosService.Update(entity: Entity);

                    if (result.CodeError != 0)
                    {
                        throw new Exception(result.MsgError);
                    }

                    TempData[key: "Msg"] = "El registro ha sido actualizado";
                }
                else
                {
                    //Para nuevo registro
                    var result = await puestosService.Create(entity: Entity);

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
