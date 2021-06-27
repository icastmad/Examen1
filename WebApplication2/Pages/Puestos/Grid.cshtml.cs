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
    public class GridModel : PageModel
    {
        private readonly IPuestosService puestosService;

        public GridModel(IPuestosService puestosService)
        {
            this.puestosService = puestosService;
        }

        public IEnumerable<PuestosEntity> GridListPuestos { get; set; } = new List<PuestosEntity>();

        public string Mensaje { get; set; } = "";

        public async Task<IActionResult> OnGet()
        {
            try
            {
                GridListPuestos = await puestosService.Get();

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
                var result = await puestosService.Delete(new()
                {

                   Id_Puesto = id
                });

                if (result.CodeError != 0)
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
