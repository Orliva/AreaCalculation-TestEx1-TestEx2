use EX2

select Product.[Name] as ProductName, Category.[Name] as CategoryName from Product
left outer join HelpTable
on HelpTable.ProdId = Product.Id 
left outer join Category
on HelpTable.CategoryId = Category.Id