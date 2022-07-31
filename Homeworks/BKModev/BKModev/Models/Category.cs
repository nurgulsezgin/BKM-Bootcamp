// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace BKModev.Models;

public class Category
{
    public int Id { get; set; }
    public string CategoryName { get; set; }
    public List<Product> Products { get; set; }
}
