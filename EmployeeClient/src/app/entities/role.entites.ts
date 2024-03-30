import { EmployeeRole } from "./employeeRole.entites"

export class Role {
    id!: number
    roleName!: string
    // isManagementRole!: boolean
    employeeRoles!: EmployeeRole[]
}