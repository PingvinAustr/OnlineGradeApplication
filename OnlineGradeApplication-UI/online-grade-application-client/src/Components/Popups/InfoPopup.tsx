
import React from 'react';
import { message } from 'antd';

interface InfoPopupProps {
    content: string;
}

const InfoPopup: React.FC<InfoPopupProps> = ({ content }) => {
    React.useEffect(() => {
        message.info(content);
    }, [content]);

    return null;
};

export default InfoPopup;
