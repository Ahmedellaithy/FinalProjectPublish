﻿using Microsoft.EntityFrameworkCore;

namespace FinalProject.Core.Pagination;

public static class Extensions
{
    public static async Task<PaginationResponseOutput<T>> ToPaginatedListAsync<T>(this IQueryable<T> source, int pageNumber, int pageSize)
        where T : class
    {
        if (source == null)
        {
            throw new Exception("Empty");
        }

        pageNumber = pageNumber == 0 ? 1 : pageNumber;
        pageSize = pageSize == 0 ? 10 : pageSize;
        int count = await source.AsNoTracking().CountAsync();
        if (count==0) return PaginationResponseOutput<T>.Success(new List<T>(), count, pageNumber, pageSize);
        pageNumber = pageNumber <= 0 ? 1 : pageNumber;
        var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        return PaginationResponseOutput<T>.Success(items, count, pageNumber, pageSize);
    }
}