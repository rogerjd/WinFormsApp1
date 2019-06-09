select *
from RawBCs

select *
from Inventory


select rb.RawBC
from RawBCs rb
left join Inventory i on rb.RawBC = i.NDC
left join Inventory i2 on rb.NDC = i2.NDC
where i.NDC is null
group by rb.RawBC 
having COUNT(distinct rb.ndc) = 1

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