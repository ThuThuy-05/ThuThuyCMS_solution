import React from "react";

function ShopHeader({
    total,
    search,
    onSearch
}) {

    return (

        <div className="card shadow-sm border-0 mb-4">

            <div className="card-body">

                <div className="row align-items-center">

                    <div className="col-md-6">

                        <h5 className="mb-0">
                            Tìm thấy {total} sản phẩm
                        </h5>

                    </div>

                    <div className="col-md-6">

                        <input
                            type="text"
                            className="form-control"
                            placeholder="Tìm kiếm sản phẩm..."
                            value={search}
                            onChange={(e) =>
                                onSearch(e.target.value)
                            }
                        />

                    </div>

                </div>

            </div>

        </div>

    );
}

export default ShopHeader;