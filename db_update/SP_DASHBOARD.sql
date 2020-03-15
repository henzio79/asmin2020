USE [AMS]
GO

if exists(select * from sysobjects where name like 'DASHBOARD_CHART01')
	drop proc DASHBOARD_CHART01
GO

/*

exec DASHBOARD_CHART01

*/
create proc [dbo].[DASHBOARD_CHART01](@AsOfDate date = null)
as
begin
	if @AsOfDate is null
		set @AsOfDate = getdate()

	select tx.department_id, 
		tx.department_code,
		tx. department_name,
		asset_qty = count(tx.asset_id), 
		asset_value = sum(tx.asset_value )
	from (
		select a.asset_id, 
		a.asset_number,
		department_id = a.current_department_id, 
		b.department_code,
		b.department_name,
		a.category_id,
		a.company_id,
		a.asset_reg_location_id,
		a.asset_reg_pic_id,
		asset_value = c.asset_book_value_idr
		from tr_asset_registration a
		inner join ms_department b on (a.current_department_id = b.department_id and b.fl_active=1)
		inner join tr_depreciation c on (c.asset_id = a.asset_id and c.fl_active=1)
		where a.fl_active = 1
		and a.asset_type_id = 1
		and c.depreciation_type_id = 1 --SLM
		and a.asset_receipt_date <= @AsOfDate
	) tx
	group by tx.department_id, tx.department_code, tx. department_name

end

go


if exists(select * from sysobjects where name like 'DASHBOARD_CHART02')
	drop proc DASHBOARD_CHART02
GO

/*

exec DASHBOARD_CHART02

*/
create proc [dbo].[DASHBOARD_CHART02](@AsOfDate date = null)
as
begin
	if @AsOfDate is null
		set @AsOfDate = getdate()

select 
x.department_id,
x.department_code,
x.department_name,
mutation_qty = count(m.asset_id),
dispose_qty = count(d.asset_id)
from ms_department x
outer apply (

	select
	b.asset_id, b.request_date 
	from tr_mutation_request b
	where b.fl_active=1
	and b.request_date <= @AsOfDate
	and b.request_dept_id <= x.department_id


) m

outer apply (

	select asset_id, request_dept_id, a.request_date 
	from tr_disposal_request a
	where a.fl_active=1
	and a.request_date <= @AsOfDate
	and a.request_dept_id = x.department_id

) d

where x.fl_active=1
group by 
x.department_id,
x.department_code,
x.department_name

order by x.department_id asc


end

go
