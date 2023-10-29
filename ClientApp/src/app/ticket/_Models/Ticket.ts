export interface Ticket {
  id: number;
  phoneNumber: string;
  status: string;
  governorateId: number;
  districtId: number;
  cityId: number;
  createdDate: Date ;
  lastModifiedDate: Date ;
  buttonSeverity : string;
}

