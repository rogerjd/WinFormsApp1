select *
from Employees a
join (select * from Employees) e on a.FirstName > e.FirstName