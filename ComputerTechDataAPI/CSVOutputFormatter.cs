using ComputerTechAPI_DtoAndFeatures.DTO;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System.Text;

namespace ComputerTechDataAPI;

public class CSVOutputFormatter : TextOutputFormatter
{
    public CSVOutputFormatter()
    {
        SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
        SupportedEncodings.Add(Encoding.UTF8);
        SupportedEncodings.Add(Encoding.Unicode);
    }
    protected override bool CanWriteType(Type? type)
    {
        if (typeof(ProductDTO).IsAssignableFrom(type) ||
       typeof(IEnumerable<ProductDTO>).IsAssignableFrom(type))
        {
            return base.CanWriteType(type);
        }
        return false;
    }
    public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext
   context, Encoding selectedEncoding)
    {
        var response = context.HttpContext.Response;
        var buffer = new StringBuilder();
        if (context.Object is IEnumerable<ProductDTO>)
        {
            foreach (var product in (IEnumerable<ProductDTO>)context.Object)
            {
                FormatCsv(buffer, product);
            }
        }
        else
        {
            FormatCsv(buffer, (ProductDTO)context.Object);
        }
        await response.WriteAsync(buffer.ToString());
    }
    private static void FormatCsv(StringBuilder buffer, ProductDTO product)
    {
        buffer.AppendLine($"{product.Id},\"{product.Category}");
    }
}