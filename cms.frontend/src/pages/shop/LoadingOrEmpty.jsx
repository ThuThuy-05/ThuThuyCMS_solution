import React from "react";

function LoadingOrEmpty({ loading }) {

    if (loading) {

        return (

            <div className="text-center py-5">

                <div
                    className="spinner-border text-primary"
                >
                </div>

                <p className="mt-3">
                    Đang tải sản phẩm...
                </p>

            </div>

        );
    }

    return (

        <div className="alert alert-warning">

            Không tìm thấy sản phẩm.

        </div>

    );
}

export default LoadingOrEmpty;