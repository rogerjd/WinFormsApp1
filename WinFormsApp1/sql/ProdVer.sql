select *
from RawBCs

select *
from Inventory

drop table #tmp
select * into #tmp from (select * from Inventory) as x
select * from #tmp

select x.Id, x.RawBC, x.NDC, x.DrugName into #temp from (
select * --distinct(rb.RawBC)
from RawBCs rb
left join Inventory i on rb.RawBC = i.NDC
left join Inventory i2 on rb.NDC = i2.NDC
where i.NDC is null and i2.NDC is not null ) as x

select * --distinct(rb.RawBC)
from RawBCs rb
left join Inventory i on rb.RawBC = i.NDC
left join Inventory i2 on rb.NDC = i2.NDC
where i.NDC is null and i2.NDC is not null




select rb.RawBC -- * --distinct(rb.RawBC)
from RawBCs rb
left join Inventory i on rb.RawBC = i.NDC
left join Inventory i2 on rb.NDC = i2.NDC
where i.NDC is null --and i2.NDC is not null
group by rb.RawBC 
having (COUNT(distinct rb.ndc) = 1) --and i2.NDC is not null

/*
select rb.RawBC
from RawBCs rb
left join Inventory i on rb.NDC = i.NDC
join Inventory i2 on rb.NDC = i2.NDC
where i.NDC is null
group by rb.RawBC 
having COUNT(distinct rb.ndc) = 1
*/

select RawBC
from RawBCs
group by RawBC
having count(distinct ndc) = 1