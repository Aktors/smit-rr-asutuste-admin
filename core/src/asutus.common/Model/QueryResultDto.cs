﻿namespace asutus.common.Model;

public class QueryResultDto<T> where T : class
{
    public T[]? Result { get; set; }
    public int? Page { get; set; }
    public int? TotalPages { get; set; }
    public int? PageSize { get; set; }
    public int Total { get; set; }
}