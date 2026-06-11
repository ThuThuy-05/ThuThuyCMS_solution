import React from "react";
import ProductCard from "../../components/ProductCard";

function ProductList({ products }) {

    return (

        <div className="row">

            {products.map((item) => (

                <div
                    key={item.id}
                    className="col-md-4 mb-4"
                >

                    <ProductCard item={item} />

                </div>

            ))}

        </div>

    );
}

export default ProductList;