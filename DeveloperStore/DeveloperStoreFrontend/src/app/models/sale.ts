export interface Sale {
  id: number;
  saleNumber: string;
  saleDate: Date;
  customerId: number;
  customerName: string;
  totalAmount: number;
  branchId: number;
  branchName: string;
  items: SaleItem[];
  isCancelled: boolean;
}

export interface SaleItem {
  id: number;
  productId: number;
  productName: string;
  quantity: number;
  unitPrice: number;
  discount: number;
  totalItemAmount: number;
}
