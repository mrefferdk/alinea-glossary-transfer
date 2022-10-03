using System;
using System.Collections.Generic;
using System.Linq;
using console_sandbox;
using System.Text.Json;
using System.Text.Json.Serialization;





class Program
{
    public static string NextEndpointUrl { get; set; } = "http://localhost:55790/api/Resource/Save";
    

    public static async Task Main(string[] args)
    {
        

        List<Portal> portals = new List<Portal>() {
            new Portal("https://thomase.cliodev.dk/portals/da-ud/?eID=glossary-words&token=17*d0flR3TLs","CEC3286C-27FD-4361-AF47-F7C23014AF38"),
            /*new Portal("https://thomase.cliodev.dk/portals/da-ud/?eID=glossary-words&token=17*d0flR3TLs","222"),
            new Portal("https://thomase.cliodev.dk/portals/da-ud/?eID=glossary-words&token=17*d0flR3TLs","222"),
            new Portal("https://thomase.cliodev.dk/portals/da-ud/?eID=glossary-words&token=17*d0flR3TLs","222"),
            new Portal("https://thomase.cliodev.dk/portals/da-ud/?eID=glossary-words&token=17*d0flR3TLs","222"),
            new Portal("https://thomase.cliodev.dk/portals/da-ud/?eID=glossary-words&token=17*d0flR3TLs","222"),
            new Portal("https://thomase.cliodev.dk/portals/da-ud/?eID=glossary-words&token=17*d0flR3TLs","222"),*/
        };

        List<GlossaryDTO> glossaryList = new List<GlossaryDTO>();

        foreach (Portal portal in portals)
        {
            ClioGlossaryService service = new ClioGlossaryService(portal.Url);
            List<ClioGlossary> items = await service.GetClioGlossaryJson();

            if (items.Count() != 0)
            {
                
                foreach (ClioGlossary clioGlossary in items)
                {
                    GlossaryDTO glossaryDTO = new GlossaryDTO(clioGlossary, portal.ProductId);
                    glossaryList.Add(glossaryDTO);


                }

            }
        }

        NextWordExplanationService nextService = new NextWordExplanationService(NextEndpointUrl);
        _ = nextService.BulkSave(glossaryList);


        string json = JsonSerializer.Serialize(glossaryList);

        Console.WriteLine(json);

        Console.ReadLine();
        
    }
}