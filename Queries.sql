--1
;with cte
as
(
select c.*, f.IdFinanciamento, count(*) 'ParcelaPagaTotal' from Cliente c
join Financiamento f on c.IdCliente = f.IdCliente
join ParcelaFinanciamento pf on pf.IdFinanciamento = f.IdFinanciamento
where c.UF = 'SP' and pf.DataPagamento is not null
group by c.IdCliente, c.Nome, c.UF, c.Celular, f.IdFinanciamento
)
select c.IdCliente, c.Nome, c.UF, c.Celular, c.IdFinanciamento from cte c
join ParcelaFinanciamento pf on pf.IdFinanciamento = c.IdFinanciamento
group by c.IdCliente, c.Nome, c.UF, c.Celular, c.IdFinanciamento, c.ParcelaPagaTotal
having cast(ParcelaPagaTotal as decimal) / count(*) > 0.6


--2
select top 4 * from cliente
where IdCliente in
(
	select IdCliente from Financiamento f
	join ParcelaFinanciamento pf on pf.IdFinanciamento = f.IdFinanciamento
	where pf.DataPagamento is null and GETDATE() > dateadd(day, 5, pf.DataVencimento)
)


--3
select * from cliente
where IdCliente in
(
	select f.IdCliente from Financiamento f
	join ParcelaFinanciamento pf on pf.IdFinanciamento = f.IdFinanciamento
	where f.ValorTotal > 10000.00 and (DATEDIFF(d, pf.DataVencimento, pf.DataVencimento) > 10 or  (pf.DataPagamento is null and GETDATE() > dateadd(day, 10, pf.DataVencimento)))
	group by IdCliente
	having count(*) >= 2
)