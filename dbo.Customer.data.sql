
            SELECT distinct  c1.Name, c1.State

            FROM Customer AS c1, Customer AS c2

            WHERE c1.State = c2.State

            AND c1.Name <> c2.Name

            ORDER BY c1.State, c1.Name;


			SELECT c1.Name, c1.State	

            FROM Customer AS c1
			
            ORDER BY c1.State, c1.Name;