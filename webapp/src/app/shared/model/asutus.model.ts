export interface QueryResponse<T> {
  result: T[],
  page: number,
  totalPages: number,
  pageSize: number,
  total: number,
}

export interface AsutusShortDto {
  code: string,
  name: string,
  startDate: Date,
  endDate?: Date,
}

export interface TranslationDto {
  code: string,
  text: string,
}

export interface AsutusDto extends AsutusShortDto{
  translations: TranslationDto[];
}
