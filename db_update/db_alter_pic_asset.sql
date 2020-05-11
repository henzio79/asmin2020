use ams
go

alter table ms_asset_register_pic add department_id int null
go

update ms_asset_register_pic set department_id=1 where asset_reg_pic_id=1
update ms_asset_register_pic set department_id=16 where asset_reg_pic_id=2
update ms_asset_register_pic set department_id=20 where asset_reg_pic_id=1003
go