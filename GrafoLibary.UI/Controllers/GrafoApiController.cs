using GrafoLibary.Libary.Algoritimos;
using GrafoLibary.Libary.Models;
using GrafoLibary.UI.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace GrafoLibary.UI.Controllers
{
    public class GrafoApiController : ApiController
    {
        // POST: api/GrafoApi
        public async Task<HttpResponseMessage> Post()
        {
            var provider = new CustomMultipartFormDataStreamProvider(HttpContext.Current.Server.MapPath("~/Content/Upload"));

            return await Request.Content.ReadAsMultipartAsync(provider).ContinueWith<HttpResponseMessage>(t =>
                {
                    if (t.IsFaulted || t.IsCanceled)
                        return Request.CreateErrorResponse(
                            HttpStatusCode.InternalServerError, t.Exception);

                    return Request.CreateResponse(HttpStatusCode.OK);
                });
        }

        // GET: api/GrafoApi/5
        public string Get(string id)
        {
            string caminho = HttpContext.Current.Server.MapPath(string.Format("~/Content/Upload/{0}.txt", id));
            List<Resposta> respostas = Algoritimos.ExecutaComandos(caminho);
            string resp = new JavaScriptSerializer().Serialize(respostas);
            return resp;
        }
    }
}
