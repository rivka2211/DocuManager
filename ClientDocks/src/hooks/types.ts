export type FileDTO = {
  id: number
  name: string;
  userId: number;
  size:string;
  category: string;
  url: string;
  UploadDate?: Date;
  IssueDate?: Date;
};
  
  export interface UserDTO {
    id: number;
    name: string;
    email: string;
    files: FileDTO[];
  }
  
  export interface UserUpdateDto {
    name?: string;
    email?: string;
  }
  
  export interface FileCreateDTO {
    fileName: string;
    fileSize: number;
  }
  
  export interface UpdateFileNameDTO {
    name: string;
  }