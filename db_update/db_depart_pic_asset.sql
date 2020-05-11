use ams
go

if exists(select * from sysobjects where name like 'FK_DEPT_ASSET_REG_PIC_ID')
	alter table ms_department drop constraint FK_DEPT_ASSET_REG_PIC_ID
go

alter table ms_department add asset_reg_pic_id int null
go
alter table ms_department add constraint FK_DEPT_ASSET_REG_PIC_ID foreign key(asset_reg_pic_id) references ms_asset_register_pic(asset_reg_pic_id)
go

declare @asset_reg_pic_id int
select @asset_reg_pic_id=asset_reg_pic_id from ms_asset_register_pic where asset_reg_pic_code='IT'
update ms_department set asset_reg_pic_id=@asset_reg_pic_id where department_code='IT'
select @asset_reg_pic_id=asset_reg_pic_id from ms_asset_register_pic where asset_reg_pic_code='HGS'
update ms_department set asset_reg_pic_id=@asset_reg_pic_id where department_code='HGS'
select @asset_reg_pic_id=asset_reg_pic_id from ms_asset_register_pic where asset_reg_pic_code='OPR'
update ms_department set asset_reg_pic_id=@asset_reg_pic_id where department_code not in (select asset_reg_pic_code from ms_asset_register_pic where asset_reg_pic_code in ('IT','HGS'))
go

ms_asset_register_pic
ms_department
