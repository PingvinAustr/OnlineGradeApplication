import React, { createContext, useContext, useState } from 'react';

interface AuthContextData {
    userId: number | null;
    userRoleId: number | null;
    setUserId: (id: number | null) => void;
    setUserRoleId: (id: number | null) => void;
}

const AuthContext = createContext<AuthContextData>({
    userId: null,
    setUserId: () => {},
    userRoleId: null,
    setUserRoleId: () => {},
});

interface AuthProviderProps {
    children: React.ReactNode;
}

export const AuthProvider: React.FC<AuthProviderProps> = ({ children }) => {
    const [userId, setUserId] = useState<number | null>(null);
    const [userRoleId, setUserRoleId] = useState<number | null>(null);

    return (
        <AuthContext.Provider value={{ userId, setUserId, userRoleId, setUserRoleId }}>
            {children}
        </AuthContext.Provider>
    );
};

export const useAuth = () => useContext(AuthContext);