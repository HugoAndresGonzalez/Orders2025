using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Shared.DTO;

public class PaginationDTO
{
    public int Id { get; set; }

    public int Page { get; set; } = 1;
    public int RecordsNumber { get; set; } = 10;
}