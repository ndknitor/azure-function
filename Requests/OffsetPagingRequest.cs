using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Localnow.Requests;
public class OffsetPagingRequest
{
    [MaxLength(48)]
    public IEnumerable<bool> Desc { get; set; }
    [MaxLength(48)]
    public virtual IEnumerable<string> OrderBy { get; set; }
    [Range(1, int.MaxValue)]
    public int Page { get; set; } = 1;
    [Range(1, 128)]
    public int Size { get; set; } = 64;
    public int Offset { get => (Page - 1) * Size; }

    public OffsetPagingRequest(IQueryCollection query)
    {
        if (query == null)
        {
            throw new ArgumentNullException(nameof(query));
        }

        // Load query parameters
        if (query.TryGetValue("desc", out var descValues))
        {
            Desc = descValues.Select(bool.Parse);
        }

        if (query.TryGetValue("orderBy", out var orderByValues))
        {
            OrderBy = orderByValues;
        }

        if (query.TryGetValue("page", out var pageValue))
        {
            Page = int.Parse(pageValue);
        }

        if (query.TryGetValue("size", out var sizeValue))
        {
            Size = int.Parse(sizeValue);
        }
    }
}