import React from "react";
import { Product } from "../../types/Product";
import ProductCard from "./ProductCard";

const ProductList = ({ products }: { products: Product[] }) => {
  return (
    <div className="products">
      {products?.map((product) => (
        <ProductCard
          key={product.id}
          id={product.id}
          description={product.description}
          title={product.title}
          price={product.price}
          images={product.images}
        />
      ))}
    </div>
  );
};

export default ProductList;
