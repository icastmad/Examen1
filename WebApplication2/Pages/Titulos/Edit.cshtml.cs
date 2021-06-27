using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;
using Entity;
using Entity.dbo;

namespace WebApplication2.Pages.Titulos
{
    public class EditModel : PageModel
    {
        private readonly ITitulosService titulosService;

        public EditModel(ITitulosService titulosService)
        {
            this.titulosService = titulosService;
        }

        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }

        [BindProperty]
        public TitulosEntity Entity { get; set; } = new TitulosEntity();

        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await titulosService.GetById(entity:new() {Id_Titulo =id});
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
                if (Entity.Id_Titulo.HasValue)
                {
                    //Para actualizar
                   var result = await titulosService.Update(entity: Entity);

                    if (result.CodeError != 0)
                    {
                        throw new Exception(result.MsgError);
                    }

                    TempData[key: "Msg"] = "El registro ha sido actualizado";
                }
                else
                {
                    //Para nuevo registro
                    var result = await titulosService.Create(entity: Entity);

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
