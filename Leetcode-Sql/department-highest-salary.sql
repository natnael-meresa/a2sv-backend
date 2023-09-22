# Write your MySQL query statement below
SELECT Employee.name as Employee, Employee.salary as Salary, Department.name as Department 
FROM Employee 
INNER JOIN Department on Employee.departmentId = Department.id
WHERE (Employee.departmentId, Employee.salary)
IN (SELECT departmentId, Max(salary)
    FROM Employee
    GROUP BY departmentId)