export type UserTask = {
    id?: number
    title: string
    description: string
    createdDateTime: Date
    releaseDateTime: Date
    conslusionDateTime?: Date
    done: boolean
}

export type CreateUserTask = Pick<UserTask, 'title' |  'description'> & {releaseDateTime: string}
