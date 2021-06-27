using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.dbo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;

namespace WebApplication2.Pages.Titulos
{
    public class GridModel : PageModel
    {
        private readonly ITitulosService titulosService;

        public GridModel(ITitulosService titulosService)
        {
            this.titulosService = titulosService;
        }

        public IEnumerable<TitulosEntity> GridListTitulos { get; set; } = new List<TitulosEntity>();

        public string Mensaje { get; set; } = "";
        public async Task<IActionResult> OnGet()
        {
            try
            {
                GridListTitulos = await titulosService.Get();

                if (TempData.ContainsKey("Msg"))
                {
                    Mensaje = TempData[key: "Msg"] as string;

                }
                TempData.Clear();
                return Page();
            }
            catch (Exception ex)
            {

                return Content(content: ex.Message);
            }
        }

        public async Task<IActionResult> OnGetEliminar(int id)
        {
            try
            {
                var result = await titulosService.Delete( new() {

                  Id_Titulo= id
                });

                if (result.CodeError!=0)
                {
                    throw new Exception(result.MsgError);
                }

                TempData[key: "Msg"] = "El registro ha sido eliminado";

                return Redirect(url: "Grid");

            }
            catch (Exception ex)
            {

                return Content(content: ex.Message);
            }
        }
    }
}
