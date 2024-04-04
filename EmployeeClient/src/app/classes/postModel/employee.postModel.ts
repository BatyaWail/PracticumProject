
import { EmployeeRolePostModel } from "./employeeRole.postModel"

export class EmployeePostModel{
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