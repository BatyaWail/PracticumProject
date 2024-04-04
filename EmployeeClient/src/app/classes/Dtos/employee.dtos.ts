import { Data } from "@angular/router"
import { EmployeeRolePostModel } from "../postModel/employeeRole.postModel"

export class EmployeeDto{
    // id!:number
    identity!:string
    firstName!:string
    lastName!:string
    startDate!:Date
    dateOfBirth!:Date
    maleOrFmale!:boolean
    employeeRoles!:EmployeeRolePostModel[]
    status!:boolean
}